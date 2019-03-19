<?php

/**
 * Optimised for efficiency over readability
 *
 * @param string $a
 * @param string $b
 * @return int
 */
function distance(string $a, string $b): int
{
    if (($l = strlen($a)) !== strlen($b)) {
        throw new InvalidArgumentException('DNA strands must be of equal length.');
    }

    for ($d = 0, $i = 0; $i < $l; $i++) {
        $d += $a[$i] !== $b[$i];
    }

    return $d;
}
