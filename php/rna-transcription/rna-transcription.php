<?php

/**
 * Optimised for readability
 *
 * @param string $dna
 * @return string
 */
function toRna(string $dna): string
{
    return strtr(
        $dna,
        [
            'G' => 'C',
            'C' => 'G',
            'T' => 'A',
            'A' => 'U'
        ]
    );
}
