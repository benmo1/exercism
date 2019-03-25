<?php

/**
 * Optimised for readability
 *
 * @param string $candidate
 * @return bool
 */
function isIsogram(string $candidate): bool
{
    $lowerCase = mb_convert_case($candidate, MB_CASE_LOWER);

    $characters = array_diff(preg_split('//u', $lowerCase), [' ', '-', '']);

    return count(array_unique($characters)) === count($characters);
}
